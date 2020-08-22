import React from "react";
import { Grid } from "./style";
import ServerList from "../ServerList";
import ServerName from "../ServerName";
import ChannelInfo from "../ChannelInfo";

const Layout: React.FC = ({ children }) => {
  return (
    <Grid>
      <ServerList />
      <ServerName />
      <ChannelInfo />
    </Grid>
  );
};

export default Layout;
