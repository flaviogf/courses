import React from "react";
import { Button } from "./style";
import logo from "../../assets/logo.svg";

export interface Props {
  selected?: boolean;
  isHome?: boolean;
  hasNotification?: boolean;
  mentions?: number;
}

const ServerButton: React.FC<Props> = ({
  selected,
  isHome,
  hasNotification,
  mentions,
}) => {
  return (
    <Button
      selected={selected}
      isHome={isHome}
      hasNotification={hasNotification}
      mentions={mentions}
    >
      {isHome && <img src={logo} alt="Home" />}
    </Button>
  );
};

export default ServerButton;
