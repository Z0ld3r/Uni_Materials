import agentic.workflow.Agent;

public class Main {
    public static void main(String[] args) {
        try {
            Agent agent = Agent.loadAgent("test.txt");
            agent.run();
        } catch (Exception e) {
            e.printStackTrace();
        }
    }
}
