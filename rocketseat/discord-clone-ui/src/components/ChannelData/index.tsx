import React from "react";
import { Container, Messages, InputWrapper, Input, InputIcon } from "./style";
import ChannelMessage, { Mention } from "../ChannelMessage";

const ChannelData: React.FC = () => {
  return (
    <Container>
      <Messages>
        {Array.from(new Array(15)).map((it, index) => (
          <ChannelMessage
            key={index}
            author="Flávio"
            date="06/13/2020"
            content="Today is my birthday"
          />
        ))}
        <ChannelMessage
          author="Frank"
          date="06/13/2020"
          content={
            <>
              <Mention>@flaviogf</Mention> Happy birthday 🎁🎁🎁 !!!
            </>
          }
          hasMention
          isBot
        />
      </Messages>

      <InputWrapper>
        <Input type="text" placeholder="Chat on #open-chat" />
        <InputIcon />
      </InputWrapper>
    </Container>
  );
};

export default ChannelData;
