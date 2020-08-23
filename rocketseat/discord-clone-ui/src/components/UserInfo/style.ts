import styled from "styled-components";
import { Mic, Headset, Settings } from "@styled-icons/material";

export const Container = styled.div`
  align-items: center;
  background-color: var(--quaternary);
  box-shadow: rgba(0, 0, 0, 0.2) 0px 1px 0px 0px;
  display: flex;
  grid-area: user-info;
  justify-content: space-between;
  padding: 10px;
`;

export const Profile = styled.div`
  align-items: center;
  display: flex;
  justify-content: space-between;
`;

export const Avatar = styled.div`
  background-color: var(--gray);
  border-radius: 50%;
  height: 32px;
  width: 32px;
`;

export const UserData = styled.div`
  display: flex;
  flex-direction: column;
  margin-left: 8px;

  > strong {
    color: var(--white);
    font-size: 13;
  }

  > span {
    color: var(--gray);
    font-size: 13;
  }
`;

export const Icons = styled.div``;

export const MicIcon = styled(Mic)``;

export const HeadphoneIcon = styled(Headset)``;

export const SettingsIcon = styled(Settings)``;
