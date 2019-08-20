import React from 'react';

import { storiesOf } from '@storybook/react';

import FullHeader from '../components/FullHeader';

storiesOf('FullHeader', module)
  .add('with title', () => <FullHeader title="Hello" />)
  .add('with title and subtitle', () => (
    <FullHeader title="Hello" subtitle="World" />
  ))
  .add('with title, subtitle and bgColor', () => (
    <FullHeader title="Hello" subtitle="World" bgColor="blue" />
  ));
