/**
 * @format
 */

import 'react-native';
import React from 'react';
import App from '../App';
import GetIp from '../IpClient';

// Note: test renderer must be required after react-native.
import renderer from 'react-test-renderer';

it('renders correctly', () => {
  renderer.create(<App />);
});

it('calls api correctly', async () => {
  let ip = await GetIp();
  console.log(ip);
});
