import React, { useState } from 'react'

import { FaGithubAlt, FaPlus } from 'react-icons/fa'

import { Container, Card, Logo, Search, Input, Button } from './styles'

import GitHub from '../../services/github'

function Main() {
  const [search, setSearch] = useState('')
  const [repos, setRepos] = useState([])

  function onSubmit(e) {
    e.preventDefault()

    GitHub.get(`repos/${search}`)
      .then((res) => res.data)
      .then((repo) => ({ name: repo.full_name }))
      .then((repo) => setRepos([...repos, repo]))
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
          <Button type="submit">
            <FaPlus color="#ffffff" size="16px" />
          </Button>
        </Search>
      </Card>
    </Container>
  )
}

export default Main
