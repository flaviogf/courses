import styled, { keyframes, css } from 'styled-components'

export const Container = styled.div`
  min-height: 100%;
  padding: 32px 16px;
`

export const CardHeader = styled.div`
  align-items: center;
  display: flex;
  margin-bottom: 16px;

  p {
    font-weight: bold;
    margin-left: 10px;
  }
`

export const Search = styled.form`
  display: flex;
  justify-content: space-between;
  align-items: stretch;
  height: 50px;
  margin-bottom: 16px;

  input {
    border: 1px solid #dddddd;
    border-radius: 3px;
    padding: 0 12px;
    width: 100%;
  }
`

const loading = keyframes`
  from {
    transform: rotate(0deg);
  }
  to {
    transform: rotate(360deg);
  }
`

export const Button = styled.button`
  background-color: #7159c1;
  border: 1px solid #7159c1;
  border-radius: 3px;
  margin-left: 5px;
  min-width: 50px;

  &:disabled {
    opacity: 0.6;
  }

  svg {
    ${(props) =>
      props.loading &&
      css`
        animation: ${loading} 1s infinite linear;
      `}
  }
`

export const List = styled.ul`
  li {
    display: flex;
    font-size: 14px;
    justify-content: space-between;
    padding: 16px 0;

    & + li {
      border-top: 1px solid #dddddd;
    }
  }

  a {
    color: #7159c1;
    cursor: pointer;
    text-decoration: none;
  }
`
