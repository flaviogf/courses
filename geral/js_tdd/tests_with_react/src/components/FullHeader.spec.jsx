import React from 'react';
import { shallow } from 'enzyme';

import FullHeader from './FullHeader';

describe('FullHeader', () => {
  test('should have header tag when mount', () => {
    const wrapper = shallow(<FullHeader />);
    expect(wrapper.find('header')).toHaveLength(1);
  });

  describe('h1', () => {
    test('should have h1 tag when title is passed', () => {
      const wrapper = shallow(<FullHeader title="Hello" />);
      expect(wrapper.find('h1')).toHaveLength(1);
    });

    test('should not have h1 tag when title not is passed', () => {
      const wrapper = shallow(<FullHeader />);
      expect(wrapper.find('h1')).toHaveLength(0);
    });

    test('should have h1 tag with the title passed', () => {
      const wrapper = shallow(<FullHeader title="Hello" />);
      expect(wrapper.find('h1').props().children).toBe('Hello');
    });
  });

  describe('h2', () => {
    test('should have h2 tag when subtitle is passed', () => {
      const wrapper = shallow(<FullHeader subtitle="World" />);
      expect(wrapper.find('h2')).toHaveLength(1);
    });

    test('should not have h2 tag when subtitle not is passed', () => {
      const wrapper = shallow(<FullHeader />);
      expect(wrapper.find('h2')).toHaveLength(0);
    });

    test('should have h2 tag the subtitle passed', () => {
      const wrapper = shallow(<FullHeader subtitle="World" />);
      expect(wrapper.find('h2').props().children).toBe('World');
    });
  });

  describe('bgColor', () => {
    test('should default bgColor equal to #ccc when color not is passed', () => {
      const wrapper = shallow(<FullHeader />);
      expect(wrapper.get(0).props.style.backgroundColor).toBe('#ccc');
    });

    test('should bgColor equal to #f5f5f5 when bgColor is passed', () => {
      const wrapper = shallow(<FullHeader bgColor="#f5f5f5" />);
      expect(wrapper.get(0).props.style.backgroundColor).toBe('#f5f5f5');
    });
  });
});
