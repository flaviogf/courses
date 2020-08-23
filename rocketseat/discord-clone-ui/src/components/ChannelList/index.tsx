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

      <ChannelButton />
    </Container>
  );
};

export default ChannelList;
