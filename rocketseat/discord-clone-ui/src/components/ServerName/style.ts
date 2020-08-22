import styled from "styled-components";
import { ExpandMore } from "@styled-icons/material";

export const Container = styled.div`
  align-items: center;
  background-color: var(--secondary);
  box-shadow: rgba(0, 0, 0, 0.2) 0px 1px 0px 0px;
  display: flex;
  justify-content: space-between;
  padding: 0 11px 0 16px;
`;

export const Title = styled.div`
  color: var(--white);
  font-size: 16px;
  font-weight: bold;
`;

export const ExpandIcon = styled(ExpandMore)`
  color: var(--white);
  cursor: pointer;
  height: 28px;
  width: 28px;
`;
