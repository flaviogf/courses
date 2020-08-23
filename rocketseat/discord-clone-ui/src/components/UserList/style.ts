import styled from "styled-components";

export const Container = styled.div`
  background-color: var(--secondary);
  display: flex;
  flex-direction: column;
  grid-area: user-list;
  max-height: calc(100vh - 46px);
  overflow-y: scroll;
  padding: 3px 6px 0 16px;

  ::-webkit-scrollbar {
    width: 4px;
  }

  ::-webkit-scrollbar-thumb {
    background-color: var(--tertiary);
    border-radius: 4px;
  }

  ::-webkit-scrollbar-track {
    background-color: var(--secondary);
  }
`;

export const Role = styled.div`
  color: var(--gray);
  font-size: 12px;
  font-weight: 500;
  margin-top: 20px;
  text-transform: uppercase;
`;

export const User = styled.div`
  align-items: center;
  background: transparent;
  border-radius: 4px;
  cursor: pointer;
  display: flex;
  margin: 5px;
  padding: 5px;
  transition: background 0.2s;

  &:hover {
    background: rgba(255, 255, 255, 0.1);
  }

  > strong {
    color: var(--white);
    font-weight: 500;
    margin-left: 13px;
    opacity: 0.7;
    overflow: hidden;
    text-overflow: ellipsis;
    white-space: nowrap;
  }

  > span {
    background-color: var(--discord);
    border-radius: 4px;
    color: var(--white);
    font-size: 11px;
    font-weight: 500;
    margin-left: 9px;
    padding: 4px 5px;
    text-transform: uppercase;
  }
`;

export const Avatar = styled.div`
  background-color: var(--primary);
  border-radius: 50%;
  flex-shrink: 0;
  height: 32px;
  width: 32px;

  &.bot {
    background-color: var(--mention-detail);
  }
`;
