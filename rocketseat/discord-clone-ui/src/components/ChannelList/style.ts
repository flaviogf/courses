import styled from "styled-components";
import { Add } from "@styled-icons/material";

export const Container = styled.div`
  background-color: var(--secondary);
  display: flex;
  flex-direction: column;
  grid-area: channel-list;
  padding: 24px 9.5px 0 16px;
`;

export const Category = styled.div`
  align-items: center;
  display: flex;
  justify-content: space-between;
  margin-bottom: 6px;

  > span {
    color: var(--gray);
    font-size: 12px;
    font-weight: 500;
    text-transform: uppercase;
  }
`;

export const AddCategoryIcon = styled(Add)`
  color: var(--symbol);
  cursor: pointer;
  height: 21px;
  width: 21px;
`;
