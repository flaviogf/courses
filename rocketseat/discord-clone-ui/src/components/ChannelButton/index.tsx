import React from "react";
import { Container, HashtagIcon, InviteIcon, SettingsIcon } from "./style";

const ChannelButton: React.FC = () => {
  return (
    <Container>
      <div>
        <HashtagIcon />
        <span>open-chat</span>
      </div>

      <div>
        <InviteIcon />
        <SettingsIcon />
      </div>
    </Container>
  );
};

export default ChannelButton;
