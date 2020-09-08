import React, { useEffect, useState } from 'react'
import { FiChevronLeft, FiChevronRight } from 'react-icons/fi'
import { Link, useParams } from 'react-router-dom'
import logo from '../../assets/logo.svg'
import api from '../../services/api'
import { Header, RepositoryInfo, Issues } from './style'

const Repository: React.FC = () => {
  const [repository, setRepository] = useState<Repository | null>(null)
  const [issues, setIssues] = useState<Issue[]>([])

  const params = useParams<RepositoryParams>()

  useEffect(() => {
    api
      .get<Repository>(`/repos/${params.full_name}`)
      .then((res) => res.data)
      .then(setRepository)

    api
      .get(`/repos/${params.full_name}/issues`)
      .then((res) => res.data)
      .then(setIssues)
  }, [params.full_name])

  return (
    <>
      <Header>
        <img src={logo} alt="Github Explorer" />
        <Link to="">
          <FiChevronLeft size={20} />
          Voltar
        </Link>
      </Header>

      {repository && (
        <RepositoryInfo>
          <header>
            <img src={repository.owner.avatar_url} alt={repository.owner.login} />
            <div>
              <strong>{repository.full_name}</strong>
              <p>{repository.description}</p>
            </div>
          </header>

          <ul>
            <li>
              <strong>{repository.stargazers_count}</strong>
              <span>Stars</span>
            </li>
            <li>
              <strong>{repository.forks_count}</strong>
              <span>Forks</span>
            </li>
            <li>
              <strong>{repository.open_issues_count}</strong>
              <span>Open Issues</span>
            </li>
          </ul>
        </RepositoryInfo>
      )}

      <Issues>
        {issues.map((it) => (
          <a key={it.id} href={it.html_url} target="_blank">
            <div>
              <strong>{it.title}</strong>
              <p>{it.user.login}</p>
            </div>
            <FiChevronRight size={20} />
          </a>
        ))}
      </Issues>
    </>
  )
}

interface RepositoryParams {
  full_name: string
}

interface Repository {
  description: string
  forks_count: number
  full_name: string
  owner: {
    avatar_url: string
    login: string
  }
  open_issues_count: number
  stargazers_count: number
}

interface Issue {
  id: number
  html_url: string
  title: string
  user: {
    login: string
  }
}

export default Repository
