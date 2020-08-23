import styled from "styled-components";
import { AlternateEmail } from "@styled-icons/material";

export const Container = styled.div`
  background-color: var(--primary);
  display: flex;
  flex-direction: column;
  grid-area: channel-data;
  justify-content: space-between;
`;

export const Messages = styled.div`
  display: flex;
  flex-direction: column;
  max-height: calc(100vh - 46px - 68px);
  overflow-y: scroll;
  padding: 20px 0;

  ::-webkit-scrollbar {
    width: 8px;
  }

  ::-webkit-scrollbar-thumb {
    background-color: var(--tertiary);
    border-radius: 4px;
  }

  ::-webkit-scrollbar-track {
    background-color: var(--secondary);
  }
`;

export const InputWrapper = styled.div`
  padding: 0 16px;
  width: 100%;
`;

export const Input = styled.input`
  background-color: var(--chat-input);
  border-radius: 7px;
  color: var(--white);
  height: 44px;
  padding: 0 10px 0 57px;
  position: relative;
  width: 100%;

  &::placeholder {
    color: var(--gray);
  }

  ~ svg {
    left: 14px;
    position: relative;
    top: -50%;
    transition: 180ms ease-in-out;
  }
`;

export const InputIcon = styled(AlternateEmail)`
  color: var(--gray);
  height: 24px;
  width: 24px;
`;
