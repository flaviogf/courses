import styled from 'styled-components'

export const Header = styled.header`
  align-items: center;
  display: flex;
  justify-content: space-between;

  a {
    align-items: center;
    color: #a8a8b3;
    display: flex;
    text-decoration: none;
    transition: color 0.2s;

    &:hover {
      color: #666;
    }

    svg {
      display: block;
      margin-right: 4px;
    }
  }
`

export const RepositoryInfo = styled.div`
  margin-top: 80px;

  header {
    align-items: center;
    display: flex;

    img {
      border-radius: 50%;
      height: 120px;
      width: 120px;
    }

    div {
      margin-left: 24px;

      strong {
        color: #3d3d4d;
        font-size: 36px;
      }

      p {
        color: #737380;
        font-size: 18px;
        margin-top: 4px;
      }
    }
  }

  ul {
    display: flex;
    list-style: none;
    margin-top: 40px;

    li {
      & + li {
        margin-left: 80px;
      }

      strong {
        color: #3d3d4d;
        display: block;
        font-size: 36px;
      }

      span {
        color: #6c6c80;
        display: block;
        margin-top: 4px;
      }
    }
  }
`

export const Issues = styled.div``
