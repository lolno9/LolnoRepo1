package BackEnd;
import java.util.*;
import java.net.InetAddress;
public class PortDiscoverer implements Runnable{
	private int port;	
	InetAddress ipS;
	public void run(String ip, int port){
		setIP(ip);
		portIsAviable(ipS, port);
	}
	public static boolean portIsAviable(InetAddress host, int port){
		try(var sS = new ServerSocket(host, port);
								var dS = new DatagramSocket(port)){
									return true;			
		} catch(IOException e){
			return false;
		}
	}
	public void setIP(String ip){
		ipS = InetAddress.getByName(ip);
	}
	public String getIpS(){
		return ipS.getHostAddress();
	}
	public String toString(){
		return getIpS()+" \tpuerto "+getPort;
	}
	public String getPort(){
		return this.port;
	}
	public void setPort(String p){
		this.port=p;
	}
}