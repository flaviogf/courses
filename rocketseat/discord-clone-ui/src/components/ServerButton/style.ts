import styled from "styled-components";
import { Props } from "./index";

export const Button = styled.button<Props>`
  align-items: center;
  background-color: ${(props) =>
    props.isHome ? "var(--rocketseat)" : "var(--primary)"};
  border-radius: 50%;
  cursor: pointer;
  display: flex;
  flex-shrink: 0;
  height: 48px;
  justify-content: center;
  margin-bottom: 8px;
  position: relative;
  transition: border-radius 0.2s, background-color 0.2s;
  width: 48px;

  & > img {
    height: 24px;
    width: 24px;
  }

  &:active,
  &:hover {
    background-color: ${(props) =>
      props.isHome ? "var(--rocketseat)" : "var(--discord)"};
    border-radius: 18px;
  }

  &::before {
    background-color: var(--white);
    border-radius: 50%;
    content: "";
    display: ${(props) => (props.hasNotification ? "inline" : "none")};
    height: 9px;
    left: -17px;
    position: absolute;
    top: calc(50% - 4.5px);
    width: 9px;
  }

  &::after {
    background-color: var(--notification);
    border: 4px solid var(--quaternary);
    border-radius: 12px;
    bottom: -4px;
    color: var(--white);
    content: "${(props) => props.mentions}";
    display: ${(props) => (props.mentions ? "inline" : "none")};
    height: 16px;
    padding: 0 4px;
    position: absolute;
    right: -4px;
  }
`;
