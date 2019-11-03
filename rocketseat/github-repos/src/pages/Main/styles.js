import styled from 'styled-components'

export const Container = styled.div`
  heigth: 100%;
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

export const Button = styled.button`
  background-color: #7159c1;
  border: 1px solid #7159c1;
  border-radius: 4px;
  cursor: pointer;
  margin-left: 5px;
  width: 50px;
  min-width: 50px;
`
