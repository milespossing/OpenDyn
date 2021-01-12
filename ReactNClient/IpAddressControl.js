import React, {Component} from 'react';
import {GetIp} from './IpClient.js';
import {StyleSheet, Text, Button} from 'react-native';
import {Colors} from 'react-native/Libraries/NewAppScreen';

class IpAddressControl extends Component {
  constructor(props) {
    console.log('ctor');
    super(props);
    this.state = {address: '0.0.0.0'};
    GetIp().then((res) => this.setState({address: res}));
  }

  _handleClick() {
    GetIp().then((ip) => this.setState({address: ip}));
  }

  render() {
    return (
      <>
        <Text style={styles.sectionTitle}>IP Address</Text>
        <Text style={styles.highlight}>{this.state.address}</Text>
        <Button title={'Refresh'} onPress={() => this._handleClick()} />
      </>
    );
  }
}

const styles = StyleSheet.create({
  sectionTitle: {
    fontSize: 24,
    fontWeight: '600',
    color: Colors.black,
    alignContent: 'center',
  },
});

export default IpAddressControl;
