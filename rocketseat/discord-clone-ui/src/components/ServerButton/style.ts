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
  width: 48px;
`;
