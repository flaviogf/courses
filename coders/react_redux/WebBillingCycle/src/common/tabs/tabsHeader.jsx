import React from 'react';

const TabsHeader = (props) => (
  <div className="col s12">
    <ul className="tabs blue">{props.children}</ul>
  </div>
);

export default TabsHeader;
