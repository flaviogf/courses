import styled from "styled-components";
import { Hashtag } from "@styled-icons/heroicons-outline";

export const Container = styled.div`
  align-items: center;
  background-color: var(--primary);
  box-shadow: rgba(0, 0, 0, 0.2) 0px 1px 0px 0px;
  display: flex;
  grid-area: channel-info;
  padding: 0 17px;
`;

export const HashtagIcon = styled(Hashtag)`
  color: var(--symbol);
  height: 24px;
  width: 24px;
`;

export const Title = styled.h1`
  color: var(--white);
  font-size: 16px;
  font-weight: bold;
  margin-left: 9px;
`;

export const Separator = styled.div`
  background-color: var(--white);
  height: 24px;
  margin: 0 13px;
  opacity: 0.2;
  width: 1px;
`;

export const Description = styled.span`
  color: var(--gray);
  font-size: 15px;
`;
