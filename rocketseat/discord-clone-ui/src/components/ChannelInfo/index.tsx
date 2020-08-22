import React from "react";
import { Container, HashtagIcon, Title, Separator, Description } from "./style";

const ChannelInfo: React.FC = () => {
  return (
    <Container>
      <HashtagIcon />

      <Title>Open channel</Title>

      <Separator />

      <Description>Open channel to chat</Description>
    </Container>
  );
};

export default ChannelInfo;
