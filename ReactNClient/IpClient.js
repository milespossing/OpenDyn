const axios = require('axios');

const baseUrl = 'http://localhost:8080';
const endpointUrl = baseUrl + '/ipaddress';

export async function GetIp() {
  return await axios.get(endpointUrl).then((res) => res.data);
}

export default GetIp;
