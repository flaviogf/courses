import { NegotiationController } from "./controllers/NegotiationController";

const controller = new NegotiationController();

$("button[type=button]").click(controller.import.bind(controller));
$("form").submit(controller.add.bind(controller));
