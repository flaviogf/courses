import React from 'react';

const ContentHeader = (props) => (
  <hgroup className="header-group">
    <h3 className="header-item">{props.titulo}</h3>
    <h6 className="header-item">{props.subtitulo}</h6>
  </hgroup>
);

export default ContentHeader;
