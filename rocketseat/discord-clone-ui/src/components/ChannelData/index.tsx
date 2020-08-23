import React from "react";
import { Container, Messages, InputWrapper, Input, InputIcon } from "./style";

const ChannelData: React.FC = () => {
  return (
    <Container>
      <Messages />

      <InputWrapper>
        <Input type="text" placeholder="Chat on #open-chat" />
        <InputIcon />
      </InputWrapper>
    </Container>
  );
};

export default ChannelData;
