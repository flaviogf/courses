import React, { useEffect, useState } from 'react'
import { FiChevronRight } from 'react-icons/fi'
import { Link } from 'react-router-dom'
import { Title, Form, Repositories, Error } from './style'
import logo from '../../assets/logo.svg'
import api from '../../services/api'

const Dashboard: React.FC = () => {
  const [search, setSearch] = useState('')

  const [repositories, setRepositories] = useState<Repository[]>(() => {
    const json = localStorage.getItem('@github-explorer:repositories')

    if (!json) {
      return []
    }

    return JSON.parse(json)
  })

  const [error, setError] = useState('')

  useEffect(() => {
    localStorage.setItem('@github-explorer:repositories', JSON.stringify(repositories))
  }, [repositories])

  async function submit(event: React.FormEvent<HTMLFormElement>) {
    event.preventDefault()

    if (!search) {
      setError('Enter the author/name of a repository, please.')
      return
    }

    try {
      const { data: repository } = await api.get<Repository>(`/repos/${search}`)
      setRepositories([...repositories, repository])
      setSearch('')
      setError('')
    } catch {
      setError('Searched repository cannot be found.')
    }
  }

  return (
    <>
      <img src={logo} alt="Github Explorer" />
      <Title>Browse repositories on GitHub</Title>
      <Form hasError={!!error} onSubmit={submit}>
        <input
          value={search}
          onChange={(e) => setSearch(e.target.value)}
          placeholder="Enter the name of a repository"
        />
        <button type="submit">Search</button>
      </Form>
      {error && <Error>{error}</Error>}
      <Repositories>
        {repositories.map((it) => (
          <Link key={it.id} to={`repository/${it.full_name}`}>
            <img src={it.owner.avatar_url} alt={it.owner.login} />
            <div>
              <strong>{it.full_name}</strong>
              <p>{it.description}</p>
            </div>
            <FiChevronRight size={20} />
          </Link>
        ))}
      </Repositories>
    </>
  )
}

interface Repository {
  id: string
  full_name: string
  owner: {
    login: string
    avatar_url: string
  }
  description: string
}

export default Dashboard
