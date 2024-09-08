package app.controllers;

import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestParam;

@Controller
public class HomeController {
    @RequestMapping("/")
    public String home(Model model) {
        model.addAttribute("message", "Hello from BG");
        return "home";
    }

    @RequestMapping("/hello")
    public String greeting(
            @RequestParam(value = "myname", defaultValue = "Unknown") String myname,
            Model model) {
        model.addAttribute("username", myname);
        return "greeting";
    }
}
