import React from 'react'
import { FiChevronLeft, FiChevronRight } from 'react-icons/fi'
import { Link, useParams } from 'react-router-dom'
import logo from '../../assets/logo.svg'
import { Header, RepositoryInfo, Issues } from './style'

const Repository: React.FC = () => {
  const params = useParams<RepositoryParams>()

  return (
    <>
      <Header>
        <img src={logo} alt="Github Explorer" />
        <Link to="">
          <FiChevronLeft size={20} />
          Voltar
        </Link>
      </Header>

      <RepositoryInfo>
        <header>
          <img src="https://avatars2.githubusercontent.com/u/17479978?v=4" />
          <div>
            <strong>asdf</strong>
            <p>asdf</p>
          </div>
        </header>

        <ul>
          <li>
            <strong>1808</strong>
            <span>Stars</span>
          </li>
          <li>
            <strong>48</strong>
            <span>Forks</span>
          </li>
          <li>
            <strong>67</strong>
            <span>Issues</span>
          </li>
        </ul>
      </RepositoryInfo>

      <Issues>
        <a href="#">
          <div>
            <strong>asdf</strong>
            <p>asdf</p>
          </div>
          <FiChevronRight size={20} />
        </a>
      </Issues>
    </>
  )
}

interface RepositoryParams {
  full_name: string
}

export default Repository
