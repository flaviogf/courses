import React from "react";
import { Grid } from "./style";
import ServerList from "../ServerList";

const Layout: React.FC = ({ children }) => {
  return (
    <Grid>
      <ServerList />
    </Grid>
  );
};

export default Layout;
