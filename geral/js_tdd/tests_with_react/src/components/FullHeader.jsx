import React from 'react';
import PropTypes from 'prop-types';

export default function FullHeader({ title, subtitle, bgColor }) {
  const headerStyle = {
    backgroundColor: bgColor
  };

  return (
    <header style={headerStyle}>
      {title && <h1>{title}</h1>}
      {subtitle && <h2>{subtitle}</h2>}
    </header>
  );
}

FullHeader.propTypes = {
  title: PropTypes.string,
  subtitle: PropTypes.string,
  bgColor: PropTypes.string
};

FullHeader.defaultProps = {
  title: '',
  subtitle: '',
  bgColor: '#ccc'
};
