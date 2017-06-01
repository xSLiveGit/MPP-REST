package com.example;

import com.example.domain.EntityArgumentException;
import com.example.domain.Match;
import org.hibernate.service.spi.ServiceException;
import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.web.client.RestTemplate;

import java.util.Arrays;

/**
 * Created by grigo on 5/10/17.
 */
@SpringBootApplication
public class StartRestClient {
    private final static MatchClient matchClient=new MatchClient();
    public static void main(String[] args) throws EntityArgumentException {
        RestTemplate restTemplate=new RestTemplate();
         Match m = new Match("t1","t2","Final",20,20.0d);
        show(()->System.out.println(Arrays.toString(matchClient.getAll())));
        matchClient.create(m);
        show(()->System.out.println(Arrays.toString(matchClient.getAll())));
//        show(()->System.out.println(matchClient.delete(m.getId().toString())));
//        show(()->System.out.println(Arrays.toString(matchClient.getAll())));
        m = matchClient.getById("11");
        m.setPrice(202.0d);
        matchClient.update(m);
        show(()->System.out.println(Arrays.toString(matchClient.getAll())));

//        show(()->System.out.println(Arrays.toString(matchClient.getAll())));
//        m.setId(20000);
//        show(()->System.out.println(matchClient.create(m)));

    }

    private static void show(Runnable task) {
        try {
            task.run();
        } catch (ServiceException e) {
            //  LOG.error("Service exception", e);
            System.out.println("Service exception"+ e);
        }
    }
}

