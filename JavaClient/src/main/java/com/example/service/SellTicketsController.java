package com.example.service;




import com.example.domain.Match;
import com.example.repository.MatchRepository;
import com.example.domain.RepositoryException;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.sql.SQLException;
import java.util.List;

/**
 * Created by Sergiu on 5/21/2017.
 */

@RestController
@RequestMapping("/matches")
public class SellTicketsController {


    private final MatchRepository matchRepository;

    @Autowired
    public SellTicketsController(MatchRepository matchRepository) {
        this.matchRepository = matchRepository;
    }

    @RequestMapping(method = RequestMethod.GET )
    public List<Match> getAll() throws RepositoryException {
        return this.matchRepository.getAll();
    }

    @RequestMapping(value ="/{id}", method = RequestMethod.GET)
    public ResponseEntity<?> findById(@PathVariable String id) throws RepositoryException {
        try {
            Match match = this.matchRepository.findById(Integer.parseInt(id));
            return new ResponseEntity<>(match, HttpStatus.OK);
        } catch (Exception e) {
            if(e instanceof RepositoryException)
                return new ResponseEntity<>(e.getMessage(), HttpStatus.NOT_FOUND);
            return new ResponseEntity<>("Invalid id format", HttpStatus.BAD_REQUEST);
        }
    }

    @RequestMapping(method = RequestMethod.POST)
    @ResponseBody
    public ResponseEntity<String> add(@RequestBody Match match)
    {
        try {
            this.matchRepository.add(match);
            return new ResponseEntity<>("Success", HttpStatus.OK);
        } catch (RepositoryException | SQLException e) {
            return new ResponseEntity<>(e.getMessage(), HttpStatus.BAD_REQUEST);
        }
    }

    @RequestMapping(method = RequestMethod.PUT)
    @ResponseBody
    public ResponseEntity<String> update(@RequestBody Match match)
    {
        try {
            this.matchRepository.update(match);
            return new ResponseEntity<>("Success", HttpStatus.OK);
        } catch (RepositoryException e) {
            return new ResponseEntity<>(e.getMessage(), HttpStatus.BAD_REQUEST);
        }
    }

    @RequestMapping(value="/{id}", method= RequestMethod.DELETE)
    public ResponseEntity<String> delete(@PathVariable String id){
        try {
            this.matchRepository.delete(new Integer(id));
            return new ResponseEntity<>("SUCCESS!", HttpStatus.OK);
        }catch (RepositoryException ex){
            return new ResponseEntity<>(ex.getMessage(), HttpStatus.BAD_REQUEST);
        }
    }

}
