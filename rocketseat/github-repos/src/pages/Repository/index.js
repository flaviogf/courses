import React, { useState, useEffect } from 'react'
import { Link, useParams } from 'react-router-dom'

import { Card } from '../../components/Card'

import { Container, CardHeader, List, Issue, Tags } from './styles'

import GitHub from '../../services/github'

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
      setRepo({
        avatar_url: repo.owner.avatar_url,
        description: repo.description,
        name: repo.name,
      })
      return [issues, repo]
    }

    Promise.all([findIssues(), findRepo()])
      .then((responses) => responses.map((it) => it.data))
      .then(updateIssues)
      .then(updateRepo)
  }, [name])

  return (
    <Container>
      <Card>
        <CardHeader>
          <Link to="/">Voltar aos repositorios</Link>

          <img src={repo.avatar_url} alt={repo.name} />

          <h1>{repo.name}</h1>

          <p>{repo.description}</p>
        </CardHeader>

        <List>
          {issues.map((it) => (
            <Issue key={String(it.id)}>
              <img src={it.user.avatar_url} alt="user" />

              <div>
                <h3>{it.title}</h3>
                <p>{it.user.login}</p>

                {it.labels.length ? (
                  <Tags>
                    {it.labels.map((it) => (
                      <span key={it.id}>{it.name}</span>
                    ))}
                  </Tags>
                ) : null}
              </div>
            </Issue>
          ))}
        </List>
      </Card>
    </Container>
  )
}

export default Repository
