import React from "react";
import { Container, Category, AddCategoryIcon } from "./style";
import ChannelButton from "../ChannelButton";

const ChannelList: React.FC = () => {
  return (
    <Container>
      <Category>
        <span>Text Channels</span>

        <AddCategoryIcon />
      </Category>

      <ChannelButton channelName="open-chat" />
      <ChannelButton channelName="job" />
      <ChannelButton channelName="cs-go" />
      <ChannelButton channelName="lol" />
    </Container>
  );
};

export default ChannelList;
