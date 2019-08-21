import React from 'react';

import { storiesOf } from '@storybook/react';

import FullHeader from '../components/FullHeader';

storiesOf('FullHeader', module)
  .add('with title', () => <FullHeader title="JS" />)
  .add('with title and subtitle', () => (
    <FullHeader title="JS" subtitle="TDD com javascript" />
  ))
  .add('with title, subtitle and bgColor', () => (
    <FullHeader title="JS" subtitle="TDD com javascript" bgColor="blue" />
  ))
  .add('with title, subtitle, bgColor, textColor and font', () => (
    <FullHeader
      title="JS"
      subtitle="TDD com javascript"
      bgColor="blue"
      textColor="white"
      font="Open Sans, sans-serif"
    />
  ));
