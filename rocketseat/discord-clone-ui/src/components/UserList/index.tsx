import React from "react";
import { Container, Role, User, Avatar } from "./style";

const UserList: React.FC = () => {
  return (
    <Container>
      <Role>Online - 1</Role>
      <UserRow username="Frank" />

      <Role>Offline - 1</Role>
      <UserRow username="Fernando" isBot />
    </Container>
  );
};

export interface UserRowProps {
  username: string;
  isBot?: boolean;
}

const UserRow: React.FC<UserRowProps> = ({ username, isBot }) => {
  return (
    <User>
      <Avatar className={isBot ? "bot" : ""} />
      <strong>{username}</strong>
      {isBot && <span>Bot</span>}
    </User>
  );
};

export default UserList;
