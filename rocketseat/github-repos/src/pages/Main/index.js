import React, { useState } from 'react'
import { Link } from 'react-router-dom'
import { FaGithubAlt, FaPlus, FaTrash, FaSpinner } from 'react-icons/fa'

import { Container, Card, Logo, Search, Input, Button, List } from './styles'

import GitHub from '../../services/github'

function Main() {
  const [loading, setLoading] = useState(false)
  const [search, setSearch] = useState('')
  const [repos, setRepos] = useState([{ id: 2126244, name: 'twbs/bootstrap' }])

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
      .then((repo) => ({ id: repo.id, name: repo.full_name }))
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
            <li key={String(it.id)}>
              <Link to={`repository/${encodeURIComponent(it.name)}`}>
                {it.name}
              </Link>
              <button type="button">
                <FaTrash color="#dddddd" size="16px" />
              </button>
            </li>
          ))}
        </List>
      </Card>
    </Container>
  )
}

export default Main
