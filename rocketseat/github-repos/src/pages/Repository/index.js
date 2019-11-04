import React, { useState, useEffect } from 'react'
import { useParams } from 'react-router-dom'

import GitHub from '../../services/github'

import { Container, Avatar, List, Issue } from './styles'

function Repository() {
  const { name } = useParams()
  const [repo, setRepo] = useState({})
  const [issues, setIssues] = useState([])

  useEffect(() => {
    const repoName = decodeURIComponent(name)

    function findIssues() {
      return GitHub.get(`repos/${repoName}/issues?state=all&per_page=5`)
    }

    function findRepo() {
      return GitHub.get(`/repos/${decodeURIComponent(name)}`)
    }

    function updateIssues([issues, repo]) {
      setIssues(issues)
      return [issues, repo]
    }

    function updateRepo([issues, repo]) {
      setRepo({ avatar_url: repo.owner.avatar_url })
      return [issues, repo]
    }

    Promise.all([findIssues(), findRepo()])
      .then((responses) => responses.map((it) => it.data))
      .then(updateIssues)
      .then(updateRepo)
  }, [name])

  return (
    <Container>
      <Avatar src={repo.avatar_url} />

      <List>
        {issues.map((it) => (
          <Issue key={String(it.id)}>
            <img src={it.user.avatar_url} alt="user" />
            <span>{it.title}</span>
          </Issue>
        ))}
      </List>
    </Container>
  )
}

export default Repository
