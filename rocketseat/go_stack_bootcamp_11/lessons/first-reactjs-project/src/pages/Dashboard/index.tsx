import React, { useState } from 'react'
import { FiChevronRight } from 'react-icons/fi'
import { Title, Form, Repositories } from './style'
import logo from '../../assets/logo.svg'
import api from '../../services/api'

const Dashboard: React.FC = () => {
  const [search, setSearch] = useState('')
  const [repositories, setRepositories] = useState<Repository[]>([])

  async function submit(event: React.FormEvent<HTMLFormElement>) {
    event.preventDefault()

    const { data: repository } = await api.get<Repository>(`/repos/${search}`)

    setRepositories([...repositories, repository])
    setSearch('')
  }

  return (
    <>
      <img src={logo} alt="Github Explorer" />
      <Title>Browse repositories on GitHub</Title>
      <Form onSubmit={submit}>
        <input
          value={search}
          onChange={(e) => setSearch(e.target.value)}
          placeholder="Enter the name of a repository"
        />
        <button type="submit">Search</button>
      </Form>
      <Repositories>
        {repositories.map((it) => (
          <a key={it.id} href="#">
            <img src={it.owner.avatar_url} alt={it.owner.login} />
            <div>
              <strong>{it.full_name}</strong>
              <p>{it.description}</p>
            </div>
            <FiChevronRight size={20} />
          </a>
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
