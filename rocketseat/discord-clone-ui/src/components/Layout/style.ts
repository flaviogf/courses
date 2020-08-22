import styled from "styled-components";

export const Grid = styled.div`
  display: grid;
  grid-template-columns: 71px 240px auto 240px;
  grid-template-rows: 46px auto 52px;
  grid-template-areas:
    "server-list server-name channel-info channel-info"
    "server-list channel-list channel-data user-list"
    "server-list user-info channel-data user-list";
  height: 100%;
`;
