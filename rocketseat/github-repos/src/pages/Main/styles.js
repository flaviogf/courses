import styled, { keyframes, css } from 'styled-components'

export const Container = styled.div`
  height: 100%;
  padding: 72px 16px 16px 16px;
`

export const Card = styled.form`
  background-color: #ffffff;
  border-radius: 4px;
  display: flex;
  flex-direction: column;
  margin: 0 auto;
  max-width: 640px;
  padding: 36px 16px 16px 16px;
  position: relative;
`

export const Logo = styled.div`
  align-items: center;
  background-color: #7519c1;
  border-radius: 50%;
  box-shadow: rgba(0, 0, 0, 0.3) 0px 2px 10px;
  display: flex;
  height: 75px;
  left: 50%;
  justify-content: center;
  margin-bottom: 16px;
  position: absolute;
  top: -50px;
  transform: translateX(-50%);
  width: 75px;
`

export const Search = styled.div`
  display: flex;
  flex-direction: row;
  justify-content: center;
`

export const Input = styled.input`
  font-weight: 300;
  border: 1px solid #eeeeee;
  border-radius: 4px;
  height: 50px;
  padding: 5px 8px;
  width: 100%;
`

const loading = keyframes`
  from {
    transform: rotate(0deg);
  }
  to {
    transform: rotate(360deg);
  }
`

export const Button = styled.button.attrs((props) => ({
  type: 'submit',
  disabled: props.loading,
}))`
  align-items: center;
  background-color: #7159c1;
  border: 1px solid #7159c1;
  border-radius: 4px;
  cursor: pointer;
  display: flex;
  justify-content: center;
  margin-left: 5px;
  width: 50px;
  min-width: 50px;

  &:disabled {
    cursor: not-allowed;
    opacity: 0.6;
  }

  ${(props) =>
    props.loading &&
    css`
      svg {
        animation: ${loading} 2s linear infinite;
      }
    `}
`

export const List = styled.ul`
  li {
    align-items: center;
    display: flex;
    justify-content: space-between;
    margin: 8px 0;
    padding: 8px 0;

    &:first-child {
      margin-top: 16px;
    }

    & + li {
      border-top: 1px solid #eeeeee;
    }

    a {
      color: #333333;
      font-size: 14px;
      font-weight: 700;
      text-decoration: none;
    }

    button {
      align-items: center;
      background-color: transparent;
      border: none;
      color: #aaaaaa;
      cursor: pointer;
      display: flex;
      justify-content: center;
      margin-left: 5px;
      width: 50px;
      min-width: 50px;
      transition: color 0.2s;

      &:hover {
        color: #7159c1;
      }
    }
  }
`
