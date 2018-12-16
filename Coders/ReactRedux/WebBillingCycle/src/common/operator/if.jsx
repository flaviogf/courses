import React from 'react';

export default (props) => {
  if (props.condicao) {
    return props.children;
  }
  return false;
};
