import React from "react";

import { Container, ServerName, Separator } from "./style";

const ServerList: React.FC = () => {
  return (
    <Container>
      <ServerName />
      <Separator />
      <ServerName />
      <ServerName />
    </Container>
  );
};

export default ServerList;
