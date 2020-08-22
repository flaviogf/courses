import React from "react";
import { Grid } from "./style";
import ServerList from "../ServerList";
import ServerName from "../ServerName";

const Layout: React.FC = ({ children }) => {
  return (
    <Grid>
      <ServerList />
      <ServerName />
    </Grid>
  );
};

export default Layout;
