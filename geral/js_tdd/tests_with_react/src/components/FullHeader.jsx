import React from 'react';
import PropTypes from 'prop-types';

const headerStyle = {
  display: 'flex',
  height: '100vh',
  justifyContent: 'center',
  flexDirection: 'column',
  alignItems: 'center'
};

export default function FullHeader({
  title,
  subtitle,
  bgColor,
  textColor,
  font
}) {
  const customHeaderStyle = {
    ...headerStyle,
    backgroundColor: bgColor,
    color: textColor,
    fontFamily: font
  };

  return (
    <header style={customHeaderStyle}>
      {title && <h1>{title}</h1>}
      {subtitle && <h2>{subtitle}</h2>}
    </header>
  );
}

FullHeader.propTypes = {
  title: PropTypes.string,
  subtitle: PropTypes.string,
  bgColor: PropTypes.string,
  textColor: PropTypes.string,
  font: PropTypes.string
};

FullHeader.defaultProps = {
  title: '',
  subtitle: '',
  bgColor: '#ccc',
  textColor: '#323232',
  font: 'sans-serif'
};
