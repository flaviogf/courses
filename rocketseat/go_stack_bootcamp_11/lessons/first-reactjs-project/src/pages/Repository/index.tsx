import React from 'react'
import { useParams } from 'react-router-dom'

const Repository: React.FC = () => {
  const params = useParams<RepositoryParams>()

  return <h1>Repository {params.full_name}</h1>
}

interface RepositoryParams {
  full_name: string
}

export default Repository
