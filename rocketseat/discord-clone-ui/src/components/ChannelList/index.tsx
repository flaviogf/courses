import React from "react";
import { Container, Category, AddCategoryIcon } from "./style";

const ChannelList: React.FC = () => {
  return (
    <Container>
      <Category>
        <span>Text Channels</span>

        <AddCategoryIcon />
      </Category>
    </Container>
  );
};

export default ChannelList;
