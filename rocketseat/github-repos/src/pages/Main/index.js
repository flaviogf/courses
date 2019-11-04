import React, { useState, useEffect, useRef } from 'react'
import { Link } from 'react-router-dom'
import { FaGithubAlt, FaPlus, FaTrashAlt, FaSpinner } from 'react-icons/fa'

import { Container, Card, Logo, Search, Input, Button, List } from './styles'

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
      <Card onSubmit={onSubmit}>
        <Logo>
          <FaGithubAlt color="#ffffff" size="48px" />
        </Logo>

        <Search>
          <Input
            onChange={(e) => setSearch(e.target.value)}
            placeholder="Add repository"
            value={search}
          />
          <Button loading={loading}>
            {loading ? (
              <FaSpinner color="#ffffff" size="16px" />
            ) : (
              <FaPlus color="#ffffff" size="16px" />
            )}
          </Button>
        </Search>

        <List>
          {repos.map((it) => (
            <li key={it.name}>
              <Link to={`repository/${encodeURIComponent(it.name)}`}>
                {it.name}
              </Link>
              <button type="button">
                <FaTrashAlt size="16px" />
              </button>
            </li>
          ))}
        </List>
      </Card>
    </Container>
  )
}

export default Main
