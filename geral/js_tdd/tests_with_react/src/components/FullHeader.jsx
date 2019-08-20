import React from 'react';
import PropTypes from 'prop-types';

export default function FullHeader({ title, subtitle }) {
  return (
    <header>
      {title && <h1>{title}</h1>}
      {subtitle && <h2>{subtitle}</h2>}
    </header>
  );
}

FullHeader.propTypes = {
  title: PropTypes.string,
  subtitle: PropTypes.string
};

FullHeader.defaultProps = {
  title: '',
  subtitle: ''
};
