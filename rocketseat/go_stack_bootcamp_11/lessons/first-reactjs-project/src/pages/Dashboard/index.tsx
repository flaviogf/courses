import React from 'react'
import { FiChevronRight } from 'react-icons/fi'
import { Title, Form, Repositories } from './style'
import logo from '../../assets/logo.svg'

const Dashboard: React.FC = () => (
  <>
    <img src={logo} alt="Github Explorer" />
    <Title>Browse repositories on GitHub</Title>
    <Form>
      <input placeholder="Enter the name of a repository" />
      <button type="submit">Search</button>
    </Form>
    <Repositories>
      <a href="#">
        <img
          src="https://avatars0.githubusercontent.com/u/17479978?s=460&u=c6050ae9efb110dc7efc1d280a7442cea76a1997&v=4"
          alt="flaviogf"
        />
        <div>
          <strong>flaviogf/courses</strong>
          <p>This repository is destined to save all my courses and studies.</p>
        </div>
        <FiChevronRight size={20} />
      </a>
      <a href="#">
        <img
          src="https://avatars0.githubusercontent.com/u/17479978?s=460&u=c6050ae9efb110dc7efc1d280a7442cea76a1997&v=4"
          alt="flaviogf"
        />
        <div>
          <strong>flaviogf/courses</strong>
          <p>This repository is destined to save all my courses and studies.</p>
        </div>
        <FiChevronRight size={20} />
      </a>
      <a href="#">
        <img
          src="https://avatars0.githubusercontent.com/u/17479978?s=460&u=c6050ae9efb110dc7efc1d280a7442cea76a1997&v=4"
          alt="flaviogf"
        />
        <div>
          <strong>flaviogf/courses</strong>
          <p>This repository is destined to save all my courses and studies.</p>
        </div>
        <FiChevronRight size={20} />
      </a>
    </Repositories>
  </>
)

export default Dashboard
