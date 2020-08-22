import styled from "styled-components";

export const Container = styled.div`
  align-items: center;
  background-color: var(--tertiary);
  display: flex;
  flex-direction: column;
  grid-area: server-list;
  max-height: 100vh;
  overflow-y: auto;
  padding: 11px 0;

  ::-webkit-scrollbar {
    display: none;
  }
`;

export const Separator = styled.div`
  border-bottom: 2px solid var(--quaternary);
  margin-bottom: 8px;
  width: 32px;
`;
