import React, { useState, useEffect, useRef } from 'react'
import { Link } from 'react-router-dom'
import { FaGithubAlt, FaPlus, FaSpinner } from 'react-icons/fa'

import { Card } from '../../components/Card'

import { Container, CardHeader, Search, Button, List } from './styles'

import GitHub from '../../services/github'

function useIsMount() {
  const isMount = useRef(true)

  useEffect(() => {
    isMount.current = false
  }, [])

  return isMount.current
}

function Main() {
  const isMount = useIsMount()
  const [loading, setLoading] = useState(false)
  const [search, setSearch] = useState('')
  const [repos, setRepos] = useState([{ name: 'twbs/bootstrap' }])

  useEffect(() => {
    const storageRepos = localStorage.getItem('@repos')

    if (storageRepos) {
      setRepos(JSON.parse(storageRepos))
    }
  }, [])

  useEffect(() => {
    if (!isMount) {
      localStorage.setItem('@repos', JSON.stringify(repos))
    }
  }, [isMount, repos])

  function onSubmit(e) {
    e.preventDefault()

    function beginLoading() {
      return Promise.resolve(setLoading(true))
    }

    function getRepo() {
      return GitHub.get(`repos/${search}`).then((res) => res.data)
    }

    function endLoading() {
      return Promise.resolve(setLoading(false))
    }

    beginLoading()
      .then(getRepo)
      .then((repo) => ({ name: repo.full_name }))
      .then((repo) => setRepos([...repos, repo]))
      .then(() => setSearch(''))
      .finally(endLoading)
  }

  return (
    <Container>
      <Card>
        <CardHeader>
          <FaGithubAlt />
          <p>Repositórios</p>
        </CardHeader>
        <Search onSubmit={onSubmit}>
          <input
            onChange={(e) => setSearch(e.target.value)}
            placeholder="Add repository"
            value={search}
          />
          <Button type="submit" disabled={loading} loading={loading}>
            {loading ? (
              <FaSpinner color="#ffffff" size="18px" />
            ) : (
              <FaPlus color="#ffffff" size="18px" />
            )}
          </Button>
        </Search>
        <List>
          {repos.map((it) => (
            <li key={it.name}>
              <p>{it.name}</p>
              <Link to={`repository/${encodeURIComponent(it.name)}`}>
                Detalhes
              </Link>
            </li>
          ))}
        </List>
      </Card>
    </Container>
  )
}

export default Main
