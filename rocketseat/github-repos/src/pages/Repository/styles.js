import styled from 'styled-components'

export const Container = styled.div`
  min-height: 100%;
  padding: 32px 16px;
`

export const CardHeader = styled.div`
  align-items: center
  display: flex;
  flex-direction: column;
  margin: 0 auto;
  max-width: 425px;
  text-align: center;
  width: 100%;

  a {
    color: #7159c1;
    text-decoration: none;
    margin: 8px 0;
  }

  img {
    border-radius: 50%;
    height: 100px;
    margin: 8px 0;
    width: 100px;
  }

  h1 {
    color: #333333;
    font-weight: 700;
    margin: 8px 0;
  }

  p {
    color: #222222;
    font-weight: 300;
    line-height: 1.4rem;
    margin: 8px 0;
  }

`

export const List = styled.ul`
  overflow: hidden;
`

export const Issue = styled.li`
  align-items: center;
  border: 1px solid #dddddd;
  border-radius: 3px;
  display: flex;
  margin: 8px 0;
  overflow-x: auto;
  padding: 8px;

  img {
    border-radius: 50%;
    height: 45px;
    margin: 8px 0;
    width: 45px;
  }

  div {
    display: flex;
    flex-direction: column;
    padding: 0 8px;
  }

  h3 {
    color: #333333;
    font-weight: 700;
  }

  p {
    color: #222222;
    font-weight: 300;
  }
`

export const Tags = styled.ul`
  display: flex;
  flex-wrap: wrap;
  margin: 5px 0;

  span {
    align-items: center;
    background-color: #eeeeee;
    display: flex;
    font-size: 10px;
    justify-content: center;
    margin: 5px 5px 0 0;
    padding: 3px;
  }
`
